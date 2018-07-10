import ICriteria from "../interface/iCriteria";

export default class Criteria implements ICriteria {
    OrderBy: number;
    Desc: boolean;
    Phrase: string;
    AmountOfPages: number;

    getCriteriaJSON(): object {
        return {
            orderBy: this.OrderBy,
            desc: this.Desc,
            phrase: this.Phrase,
            amountOfPages: this.AmountOfPages
        };
    };
};