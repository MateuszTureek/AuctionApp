import ICriteria from "../../customer/interface/iCriteria";

export default class ItemAjax {
    cancelItemAuction(id: number, verificationTokenVal) {
        return $.ajax({
            url: '/customer/Item/CancelAuctionOfItem',
            type: 'POST',
            data: {
                __RequestVerificationToken: verificationTokenVal,
                id: id
            }
        });
    };

    addItemToAuction(data) {
        return $.ajax({
            url: '/customer/Item/ItemToAuction',
            type: 'POST',
            data: data
        });
    };

    deleteItem(id: number, antiforgeryTokenVal) {
        return $.ajax({
            url: '/customer/Item/Delete',
            type: 'POST',
            data: {
                __RequestVerificationToken: antiforgeryTokenVal,
                id: id
            }
        });
    };

    getWaitingItems(criteria: ICriteria) {      
        return $.ajax({
            url: '/customer/Item/GetWaitingItems',
            type: 'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            data: criteria.getCriteriaJSON()
        });
    };

    getInAuctionItems(criteria: ICriteria) {
        return $.ajax({
            url: '/customer/Item/GetInAuctionItems',
            type: 'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            data: criteria.getCriteriaJSON()
        });
    };

    getBoughtItems(criteria: ICriteria) {
        return $.ajax({
            url: '/customer/Item/GetBoughtItems',
            type: 'GET',
            dataType: 'JSON',
            contentType: 'application/json',
            data: criteria.getCriteriaJSON()
        });
    };
};