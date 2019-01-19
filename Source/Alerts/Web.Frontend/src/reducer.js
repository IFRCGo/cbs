const initialState = {
    baseUrl: process.env.API_URL,
};

const reducer = (state = initialState, action) => {
    switch (action.type) {
        default: {
            return state;
        }
    }
};

export default reducer;
