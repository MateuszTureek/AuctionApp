import IObserver from "../contract/iObserver";
import IObservable from "../contract/iObservable";

export default abstract class Observable implements IObservable {
    protected observers: Array<IObserver> = [];

    add(observer: IObserver): void {
        this.observers.push(observer);
    };
    remove(observer: IObserver): void {
        const index = this.observers.indexOf(observer);
        if (index != -1) {
            this.observers.splice(index, 1);
        }
    };
    notify() {
        let i = 0, length = this.observers.length;
        for (i; i < length; i += 1) {
            this.observers[i].update();
        }
    };
};