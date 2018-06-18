import { MainNavLinkActivator } from "../mainNavLinkActivator";

/*
 * Home - home.ts
 */
const mainNav = new MainNavLinkActivator(
    $('#MainNav') as JQuery<HTMLElement>,
    'active');
mainNav.init();