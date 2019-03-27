export default function CounterApp(state = 0, action) {
    switch(action.type) {
        case 'INCREMENT':
            return state = state + 1;
        case 'DECREMENT':
            return state = state - 1;
    }
    return state;
}