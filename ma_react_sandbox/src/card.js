import React from 'react';
import ReactDOM from 'react-dom';

var destination = document.querySelector("#cardPractice");

class Card extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            colorValue: "#FF6663",
        }
    }
    render() {
        let cardStyle = {
            height: "200px",
            width: "150px",
            padding: 0,
            marginTop: "20px",
            backgroundColor: "#FFF",
            WebkitFilter: "drop-shadow(0 0 5px #666)",
            filter: "drop-shadow(0 0 5px #666)"
        }
        return (
            <div style={cardStyle}>
                <ColorSquare colorValue={this.state.colorValue}/>
                <Label colorValue={this.state.colorValue}/>
            </div>
        );
    }
}

class ColorSquare extends React.Component {
    render() {
        let squareStyle = {
            height: "150px",
            backgroundColor: this.props.colorValue,
        }
        return (
            <div style={squareStyle}></div>
        )
    }
}

class Label extends React.Component {
    render() {
        let labelStyle = {
            fontFamily: "sans-serif",
            fontWeight: "bold",
            textAlign: "center",
            padding: 0
        }
        return (
            <p style={labelStyle}>{this.props.colorValue}</p>
        );
    }
}

// ========================================

ReactDOM.render(
    <Card />,
    document.getElementById("cardPractice")
);
