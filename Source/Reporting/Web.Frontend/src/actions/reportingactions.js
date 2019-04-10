export function exampleAction(name, range) {
    return dispatch =>
        dispatch({ type: "UPDATE_EXAMPLE", payload: range, name: name });
}