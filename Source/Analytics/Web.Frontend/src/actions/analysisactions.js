export function updateRange(name, range) {
    return dispatch =>
        dispatch({ type: "UPDATE_RANGE", payload: range, name: name });
}
