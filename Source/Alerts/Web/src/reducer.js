const initialState = {
    baseUrl: process.env.API_URL,
    rules: [],
    error: null,
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        case 'RECEIVE_RULES': {
            return {
                ...state,
                rules: action.payload.rules,
            };
        }

        case 'REJECT_RULES': {
            return {
                ...state,
                error: action.payload.error,
            };
        }

        default: {
            return state;
        }
    }
};

export default reducer;
