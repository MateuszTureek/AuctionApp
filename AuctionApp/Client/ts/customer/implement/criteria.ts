import ICriteria from "../interface/iCriteria";

export default class Criteria implements ICriteria {
    OrderBy: number;
    Phrase: string;
    AmountOfPages: number;
    PageIndex: number;

    getCriteriaJSON(): object {
        return {
            orderBy: this.OrderBy,
            phrase: this.Phrase,
            amountOfPages: this.AmountOfPages,
            pageIndex: this.PageIndex
        };
    };
};