import { ILinkActivator } from "../contract/iLinkActivator";
/**
 * Class LinkActivator activates link in ul. Using session storage.
 */
export default class LinkActivator implements ILinkActivator{
    protected $linkCollection: JQuery<HTMLUListElement>;

    constructor(
        protected $ulElem: JQuery<HTMLUListElement>,
        protected active: string,
        protected sessionKey)
    {
        this.init();
    };

    init() {
        this.$linkCollection = this.$ulElem.children('li').children('a');
        this.$linkCollection.on('click', (e: Event) => { this.linkOnClick(e); });
        this.setupLink();
    };

    protected linkOnClick(e: Event) {
        e.stopPropagation();
        const $clickedLink = $(e.target);
        const clickedDataId = $clickedLink.closest('li').data('id');
        const activedDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        
        if (isNaN(activedDataId)) {
            sessionStorage.setItem(this.sessionKey, clickedDataId);
        }
        else {
            if (clickedDataId === activedDataId) return;

            const $activedLink = this.findLinkByDataId(activedDataId);
            this.deactiveLink($activedLink);
            sessionStorage.setItem(this.sessionKey, clickedDataId);
        }
    };

    protected setupLink() {
        const activeDataId = parseInt(sessionStorage.getItem(this.sessionKey));

        if (!isNaN(activeDataId)) {
            const $link = this.findLinkByDataId(activeDataId);
            this.activeLink($link);
        }
    };

    protected activeLink($link: JQuery<HTMLLinkElement>) {
        const $li = $link.closest('li');

        sessionStorage.setItem(
            this.sessionKey,
            $li.data('id'));
        $link.addClass(this.active);
    };

    protected deactiveLink($link: JQuery<HTMLLinkElement>) {
        sessionStorage.removeItem(
            this.sessionKey);
        $link.removeClass(this.active);
    }

    protected findLinkByDataId(dataId): JQuery<HTMLLinkElement> {
        let i = 0, $li: JQuery<HTMLLIElement>;
        const length = this.$linkCollection.length;

        for (i; i < length; i += 1) {
            $li = $(this.$linkCollection.get(i).closest('li')) as JQuery<HTMLLIElement>;
            if ($li.data('id') == dataId) {
                return $($li.children('a')) as JQuery<HTMLLinkElement>;
            }
        }
        throw Error('Missing dataId in current ulList.');
    };
};