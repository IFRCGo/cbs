

const hasFields = (obj, fields) => {

    return fields.filter(field => obj[field]).length === Object.keys(obj).length
}

const ob  = {
    a: "1",
    b: "2"
}

const a = hasFields(ob, ["a", "b"]);

console.log(a)