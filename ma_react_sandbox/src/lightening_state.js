import React from 'react';
import ReactDOM from 'react-dom';

class LightningCounter extends React.Component {
    render() {
        return (
            <h1>Hello!</h1>
        );
    }
}

class LightningCounterDisplay extends React.Component {
    render() {
        var divStyle = {
            width: 250,
            textAlign: "center",
            backgroundColor: "black",
            padding: 40,
            marginTop: "20px",
            fontFamily: "sans-serif",
            color: "#999",
            borderRadius: 10
        };

        return (
            <div style={divStyle}>
                <LightningCounter />
            </div>
        );
    }
}

ReactDOM.render(
    <LightningCounterDisplay />,
    document.querySelector("#lightening")
);