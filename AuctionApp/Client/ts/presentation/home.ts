import MainNavLinkActivator from "../mainNavLinkActivator";
import { AuctionSession } from "../auctionClearSession";

/*
 * Home - home.ts
 */
const mainNav = new MainNavLinkActivator(
    $('#MainNav') as JQuery<HTMLElement>,
    'active');
mainNav.init();

AuctionSession.clear();