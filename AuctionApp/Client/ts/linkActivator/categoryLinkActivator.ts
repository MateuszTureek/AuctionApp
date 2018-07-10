import LinkActivator from "./linkActivator";
import { SUBCATEGORY_KEY } from "../settings/constant";

export default class CategoryLinkActivator extends LinkActivator{
    private subcategoryLinkActivator: LinkActivator;

    init() {
        super.init();

        const activatedDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        
        if (!isNaN(activatedDataId)) {
            this.initSubcategory(activatedDataId);
        }
    };

    protected initSubcategory(activeCategoryDataId) {
        const $link = this.findLinkByDataId(activeCategoryDataId);
        const $subUl = $($link.closest('li').children('ul').first()) as JQuery<HTMLUListElement>;

        this.subcategoryLinkActivator = new LinkActivator($subUl, 'active', SUBCATEGORY_KEY);
        this.subcategoryLinkActivator.init();
    };

    protected setupLink() {
        super.setupLink();
        this.showSubcategories();
    };

    protected linkOnClick(e: Event) {
        super.linkOnClick(e);
        sessionStorage.removeItem(SUBCATEGORY_KEY);
    };

    protected showSubcategories() {
        const activatedDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        if (!isNaN(activatedDataId)) {
            const $activatedLink = this.findLinkByDataId(activatedDataId);
            $activatedLink.closest('li').children('ul').first().removeClass('d-none');
        }
    };
};