import React from 'react';
import ReactDOM from 'react-dom';

class LightningCounter extends React.Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            strikes: 0,
        };
        this.timerTick = this.timerTick.bind(this);
    }

    componentDidMount() {
        setInterval(this.timerTick, 1000);
    }
    
    timerTick() {
        let strikes = this.state.strikes;
        this.setState({
            strikes: (strikes + 100),
        });
    }


    render() {
        var counterStyle = {
            color: "#66FFFF",
            fontSize: 50
        };
        return (
            <h1 style={counterStyle}>{this.state.strikes}</h1>
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

        var commonStyle = {
            margin: 0,
            padding: 0
        };


        var textStyles = {
            emphasis: {
                fontSize: 38,
                ...commonStyle
            },
            smallEmphasis: {
                ...commonStyle
            },
            small: {
                fontSize: 17,
                opacity: 0.5,
                ...commonStyle
            }
        };

        return (
            <div style={divStyle}>
                <LightningCounter />
                <h2 style={textStyles.smallEmphasis}>LIGHTNING STRIKES</h2>
                <h2 style={textStyles.emphasis}>WORLDWIDE</h2>
                <p style={textStyles.small}>(since you loaded this example)</p>
            </div>
        );
    }
}

ReactDOM.render(
    <LightningCounterDisplay />,
    document.querySelector("#lightening")
);