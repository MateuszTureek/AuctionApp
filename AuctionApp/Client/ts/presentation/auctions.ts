import { CATEGORY_KEY, SUBCATEGORY_KEY } from "../settings/constant";
import { CategoryLinkActivator } from "../categoryLinkActivator";
/*
 * Main - auctions.ts
 */
const categoryLinkActovator = new CategoryLinkActivator(
    $('#Categories') as JQuery<HTMLUListElement>,
    'active',
    CATEGORY_KEY);

categoryLinkActovator.init();