import { CATEGORY_KEY, SUBCATEGORY_KEY, SORT_OPTION_KEY, PAGING_KEY } from "../settings/constant";
import { AuctionSession } from "../auctionClearSession";
import CategoryLinkActivator from "../linkActivator/categoryLinkActivator";
import OrderButtonLinkActivator from "../linkActivator/orderButtonLinkActivator";
import PagingLinkActivator from "../linkActivator/pagingLinkActivator";
/*
 * Main - auctions.ts
 */
$(document).ready(() => {
    const categoryLinkActovator = new CategoryLinkActivator($('#Categories') as JQuery<HTMLUListElement>, 'active', CATEGORY_KEY);
    const buttonLinkActivator = new OrderButtonLinkActivator($('#OrderByGroupButton') as JQuery<HTMLDivElement>, 'active', SORT_OPTION_KEY);
    const pagingLinkActivator = new PagingLinkActivator($('#PaginationList') as JQuery<HTMLUListElement>, 'active', PAGING_KEY);

    AuctionSession.clear();
});