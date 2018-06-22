import { CATEGORY_KEY, SUBCATEGORY_KEY, SORT_OPTION_KEY, PAGING_KEY } from "./settings/constant";

export class AuctionSession {
    static clear() {
        $('#AuctionLink').on('click', () => {
            sessionStorage.removeItem(CATEGORY_KEY);
            sessionStorage.removeItem(SUBCATEGORY_KEY);
            sessionStorage.removeItem(SORT_OPTION_KEY);
            sessionStorage.removeItem(PAGING_KEY);
        });
    }
};