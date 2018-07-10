export default class Formatter {
    constructor(private currencySign = 'pln') {
    };

    formatPrice(price: number): string {
        let formatedPrice = price.toFixed(2);
        formatedPrice += ' '+this.currencySign;
        return formatedPrice;
    };

    formatDate(date: Date): string {
        const stringDate = date.toLocaleDateString();
        const stringTime = date.toLocaleTimeString();

        let formatDate = '<span>' + stringDate + '</span> <br/> <span>' + stringTime + '</span>';

        return formatDate;
    };
};