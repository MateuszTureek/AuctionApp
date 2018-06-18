import { CATEGORY_KEY } from "../settings/constant";
import { LinkActivator } from "../linkActivator";
import { CategoryLinkActivator } from "../categoryLinkActivator";

/*
 * Main - auctions.ts
 */

/* category navigation */
const categoryLinkActovator = new CategoryLinkActivator(
    $('#Categories') as JQuery<HTMLUListElement>,
    'active',
    CATEGORY_KEY);
categoryLinkActovator.init();