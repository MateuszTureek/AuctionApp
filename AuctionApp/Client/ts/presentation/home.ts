import { AuctionSession } from "../auctionClearSession";
import MainNavLinkActivator from "../linkActivator/mainNavLinkActivator";

/*
 * Home - home.ts
 */
$(document).ready(() => {
    const mainNav = new MainNavLinkActivator($('#MainNav') as JQuery<HTMLElement>, 'active');
    AuctionSession.clear();
});