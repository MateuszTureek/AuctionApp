export default class OrderButtonLinkActivator {
    private $buttonLinks: JQuery<HTMLElement>;

    constructor(
        private $btnGroupDiv: JQuery<HTMLDivElement>,
        private active: string,
        private sessionKey: string) {
    };

    init() {
        this.$buttonLinks = this.$btnGroupDiv.children('a');
        this.$buttonLinks.on('click', (e: Event) => { this.linkOnClick(e); });

        this.setupLink();
    };

    setupLink() {
        const valueOfActiveLink = sessionStorage.getItem(this.sessionKey);
        if (valueOfActiveLink != null && valueOfActiveLink != '') {
            this.deactiveLink();

            const $activeLink = this.takeLinkByOrderByValue(valueOfActiveLink);
            this.activeLink($activeLink);
        }
        else {
            const $firstLink = this.$buttonLinks.first() as JQuery<HTMLLinkElement>;
            this.activeLink($firstLink);
        }
    };

    linkOnClick(e: Event) {
        const $clickedLink = $(e.target);
        sessionStorage.setItem(this.sessionKey, $clickedLink.data('orderBy'));
    };

    activeLink($link: JQuery<HTMLLinkElement>) {
        sessionStorage.setItem(
            this.sessionKey,
            $link.data('orderBy')
        );
        $link.addClass(this.active);
    };

    deactiveLink() {
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$buttonLinks.length;

        for (i; i < length; i += 1) {
            $link = $(this.$buttonLinks.get(0)) as JQuery<HTMLLinkElement>;
            if ($link.hasClass(this.active)) {
                $link.removeClass(this.active);
                sessionStorage.removeItem(this.sessionKey);
            }
        }
    };

    takeLinkByOrderByValue(orderByValue: string) {
        
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$buttonLinks.length;

        for (i; i < length; i += 1) {
            $link = $(this.$buttonLinks.get(i)) as JQuery<HTMLLinkElement>;
            if ($link.data('orderBy') === orderByValue) {
                return $link;
            }
        }
        throw new Error('Missing order by value in current group div.');
    };
};