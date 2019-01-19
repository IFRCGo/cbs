const initialState = {
    baseUrl: process.env.API_URL,
    rules: [],
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case 'RECEIVE_RULES': {
            return {
                ...state,
                rules: action.payload.rules,
            };
        }

        case 'RECEIVE_CREATE_RULE': {
            return state;
        }

        default: {
            return state;
        }
    }
};

export default reducer;
