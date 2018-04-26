export class Guid {
    static create() {
        let S4 = () => {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        }
        return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
    }
    static get empty() {
        return "00000000-0000-0000-0000-000000000000";
    }
}