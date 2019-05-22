const initialState = {
    baseUrl: process.env.API_URL,
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

        case 'RECEIVE_DATA_OWNER': {
            return {
                ...state,
                dataowner: action.payload.dataowner,
            };
        }

        default: {
            return state;
        }
    }
};

export default reducer;
