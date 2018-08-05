import LinkActivator from "./linkActivator";

export default class PagingLinkActivator extends LinkActivator{
    private $prevLink: JQuery<HTMLLinkElement>;
    private $nextLink: JQuery<HTMLLinkElement>;

    init() {
        this.$linkCollection = this.$ulElem.children('li').children('a').not(":first").not(":last");
        this.$prevLink = $(this.$ulElem.children('li').first()) as JQuery<HTMLLinkElement>;
        this.$nextLink = $(this.$ulElem.children('li').last()) as JQuery<HTMLLinkElement>;

        this.$linkCollection.on('click', (e: Event) => { this.linkOnClick(e); });
        this.$prevLink.on('click', () => { this.prevLinkOnClick(); });
        this.$nextLink.on('click', () => { this.nextLinkOnClick(); });

        this.setupLink();
        this.setupActivateNextAndPrevLink();
    };

    protected prevLinkOnClick() {
        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        if (!isNaN(activeDataId)) {
            const $link = this.findLinkByDataId(activeDataId);
            const $prevSibling = $link.closest('li').prev('li');
            sessionStorage.setItem(this.sessionKey, $prevSibling.data('id'));
        }
    };

    protected nextLinkOnClick() {
        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        if (!isNaN(activeDataId)) {
            const $link = this.findLinkByDataId(activeDataId);
            const $nextSibling = $link.closest('li').next('li');
            sessionStorage.setItem(this.sessionKey, $nextSibling.data('id'));
        }
    };

    protected setupLink() {
        try{
            const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));
            if (!isNaN(activeDataId)) {
                const $link = this.findLinkByDataId(activeDataId);
                this.activeLink($link);
            }
            else {
                const $firstLink = $(this.$linkCollection.first()) as JQuery<HTMLLinkElement>;
                
                const dataId = $firstLink.closest('li').data('id');
                sessionStorage.setItem(this.sessionKey, dataId);
                this.activeLink($firstLink);
            }
        }
        catch(e){
            console.log('Pagedlist not exist for empty items collection.');
        }
    };

    protected activeLink($link: JQuery<HTMLLinkElement>) {
        const $li = $link.closest('li');

        sessionStorage.setItem(
            this.sessionKey,
            $li.data('id'));
        $li.addClass(this.active);
    };

    protected deactiveLink($link: JQuery<HTMLLinkElement>) {
        const $li = $link.closest('li');

        sessionStorage.removeItem(
            this.sessionKey);
        $li.removeClass(this.active);
    }

    protected setupActivateNextAndPrevLink() {
        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        
        if (isNaN(activeDataId)) { throw new Error('Any pagination link is not active.'); }

        const firstDataId = $(this.$linkCollection.first()).closest('li').data('id') as number;
        const lastDataId = $(this.$linkCollection.last()).closest('li').data('id') as number;

        if (activeDataId === firstDataId) {
            this.disableLink(this.$prevLink);
        }
        if (activeDataId === lastDataId) {
            this.disableLink(this.$nextLink);
        }
    };

    protected disableLink($link: JQuery<HTMLLinkElement>) {
        const $li = $link.closest('li');
        $li.addClass('disabled');
    };

    protected enableLink($link) {
        const $li = $link.closest('li');
        $li.removeClass('disabled');
    };
};