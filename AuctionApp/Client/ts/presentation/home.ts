import { AuctionSession } from "../auctionClearSession";
import MainNavLinkActivator from "../linkActivator/mainNavLinkActivator";

/*
 * Home - home.ts
 */
$(document).ready(() => {
    //const mainNav = new MainNavLinkActivator($('#MainNav') as JQuery<HTMLElement>, 'active');
    //AuctionSession.clear();
    $.validator.methods.range = function (value, element, param) {
        var globalizedValue = value.replace(",", ".");
        return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
    }

    $.validator.methods.number = function (value, element) {
        return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
    }
    // impove that if fill filed and send check valid
    $.validator.addMethod("bidValid", function (value, element) {
        const bestPrice = $('#BestBid').data("bestPrice") as number;
        const myPrice = value as number;

        console.log(myPrice > bestPrice);

        return myPrice > bestPrice;
    }, 'Twoja oferta powinna być większa od bieżącej.');
});