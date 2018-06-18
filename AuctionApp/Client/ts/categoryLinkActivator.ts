import { LinkActivator } from "./linkActivator";

export class CategoryLinkActivator extends LinkActivator{
    setupLink() {
        super.setupLink();
        this.showSubcategories();
    };

    private showSubcategories() {
        const activatedDataId = parseInt(sessionStorage.getItem(this.sessionKey));
        if (!isNaN(activatedDataId)) {
            const $activatedLink = this.findLinkByDataId(activatedDataId);
            $activatedLink.closest('li').children('ul').first().removeClass('d-none');
        }
    };
};