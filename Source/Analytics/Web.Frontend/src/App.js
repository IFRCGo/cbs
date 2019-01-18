import React from 'react';
import './App.css';
import Header from "./components/sub/Header";

const App = ({children}) => {
    return (
        <div>
            <Header/>
            {children}
        </div>
        )
};

export default App;
