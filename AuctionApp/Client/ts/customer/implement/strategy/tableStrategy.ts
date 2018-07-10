import TableFactory from "../factory/tableFactory";
import { Status } from "../../../enum/status";
import TableItems from "../table/tableItems";

export default class TableStartegy {
    constructor(private tableFactory: TableFactory)
    {
    };

    getTable(status: Status): TableItems {
        let table: TableItems;

        switch (status) {
            case Status.InAuction: {
                return this.tableFactory.createInAuctionItemsTable();
            }
            case Status.Bought: {
                return this.tableFactory.createBoughtItemsTable();
            }
            default: {
                return this.tableFactory.createWaitingItemsTable();
            }
        };
    };
};