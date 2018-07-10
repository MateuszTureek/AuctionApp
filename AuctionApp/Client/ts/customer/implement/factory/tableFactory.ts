import TableItems from "../table/tableItems";
import TableOfWaitingItems from "../table/TableOfWaitingItems";
import TableOfInAuctionItems from "../table/tableOfInAuctionItems";
import TableOfBoughtItems from "../table/tableOfBoughtItems";
import Formatter from "../../../formatter";

export default class TableFactory {
    constructor(
        private itemAjax,
        private formatter: Formatter
    )
    { };

    createWaitingItemsTable(): TableItems {
        return new TableOfWaitingItems(this.itemAjax, this.formatter);
    };

    createInAuctionItemsTable(): TableItems {
        return new TableOfInAuctionItems(this.itemAjax, this.formatter);
    };

    createBoughtItemsTable(): TableItems {
        return new TableOfBoughtItems(this.itemAjax, this.formatter);
    };
};