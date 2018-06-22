import { CATEGORY_KEY, SUBCATEGORY_KEY, SORT_OPTION_KEY, PAGING_KEY } from "../settings/constant";
import OrderButtonLinkActivator from "../orderButtonLinkActivator";
import CategoryLinkActivator from "../categoryLinkActivator";
import PagingLinkActivator from "../pagingLinkActivator";
import { AuctionSession } from "../auctionClearSession";
/*
 * Main - auctions.ts
 */
const categoryLinkActovator = new CategoryLinkActivator(
    $('#Categories') as JQuery<HTMLUListElement>,
    'active',
    CATEGORY_KEY);

categoryLinkActovator.init();

const buttonLinkActivator = new OrderButtonLinkActivator(
    $('#OrderByGroupButton') as JQuery<HTMLDivElement>,
    'active',
    SORT_OPTION_KEY);
buttonLinkActivator.init();

const pagingLinkActivator = new PagingLinkActivator(
    $('#PaginationList') as JQuery<HTMLUListElement>,
    'active',
    PAGING_KEY
);
pagingLinkActivator.init();

AuctionSession.clear();