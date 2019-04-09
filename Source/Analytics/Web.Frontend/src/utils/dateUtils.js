export function pad(n, width, z) {
    z = z || "0";
    n = n + "";
    return n.length >= width ? n : new Array(width - n.length + 1).join(z) + n;
}

export function formatDate(date) {
    return (
        date.getFullYear() +
        "-" +
        pad(date.getMonth() + 1, 2) +
        "-" +
        pad(date.getDate(), 2)
    );
}

export function sevenDaysAgo() {
    const date = new Date();

    date.setDate(date.getDate() - 7);

    return date;
}

export function fromOrDefault(from) {
    return from ? new Date(from) : new Date("2019-01-01"); //sevenDaysAgo();
}

export function toOrDefault(to) {
    return to ? new Date(to) : new Date("2020-01-01"); //new Date();
}
