export default class MainNavLinkActivator {
    protected $linkCollection: JQuery<HTMLElement>;

    constructor(
        protected $navElem: JQuery<HTMLElement>,
        protected active: string) {
    }

    init() {
        this.$linkCollection = this.$navElem.children('a');
        this.setupLink();
    };

    setupLink() {
        const href = window.location.pathname;
        const $link = this.getLinkByHref(href);
        this.deactiveLink();
        this.activeLink($link);
    };

    getLinkByHref(href: string): JQuery<HTMLLinkElement> {
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$linkCollection.length;
        
        for (i; i < length; i += 1) {
            $link = $(this.$linkCollection.get(i)) as JQuery<HTMLLinkElement>;
            if ($link.attr('href') === href) {
                return $link;
            }
        }
        throw new Error("Not found matching nav link.");
    };

    activeLink($link: JQuery<HTMLLinkElement>) {
        $link.addClass(this.active);
    };

    deactiveLink() {
        let i = 0, $link: JQuery<HTMLLinkElement>;
        const length = this.$linkCollection.length;

        for (i; i < length; i += 1) {
            $link = $(this.$linkCollection.get(i)) as JQuery<HTMLLinkElement>;
            if ($link.hasClass(this.active)) {
                $link.remove(this.active);
            }
        }
    };
};