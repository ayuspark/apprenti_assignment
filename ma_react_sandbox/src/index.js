import React from 'react';
import ReactDOM from 'react-dom';

import { createStore } from "redux";
import { Provider, createProvider } from "react-redux";

import './index.css';
import './card';
import LightningCounterDisplay from './lightening_state';
import TodoList from './to-do';

// class Square extends React.Component {
//     render() {
//         return (
//             <button 
//                 className="square" 
//                 onClick={ () => this.props.onClick() }>
//                 {this.props.value}
//             </button>
//         );
//     }
// }
// NOW the Square is a Func Component
function Square(props) {
    return (
        <button className="square" onClick={props.onClick} >
            {props.value}
        </button>
    )
}

class Board extends React.Component {
    // constructor(props) {
    //     super(props);
    //     this.state = {
    //         squares: Array(9).fill(null),
    //         xIsNext: true,
    //     }
    // }
    // DELETE these codes so that Game can pass props to Boards

    renderSquare(i) {
        return (
            <Square 
                value={this.props.squares[i]}
                onClick={ () => {this.props.onClick(i)} }
            />
        );
    }

    render() {
        return (
            <div>
                {/* <div className="status">{status}</div> */}
                <div className="board-row">
                    {this.renderSquare(0)}
                    {this.renderSquare(1)}
                    {this.renderSquare(2)}
                </div>
                <div className="board-row">
                    {this.renderSquare(3)}
                    {this.renderSquare(4)}
                    {this.renderSquare(5)}
                </div>
                <div className="board-row">
                    {this.renderSquare(6)}
                    {this.renderSquare(7)}
                    {this.renderSquare(8)}
                </div>
            </div>
        );
    }
}

class Game extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            history: [{
                squares: Array(9).fill(null),
            }],
            xIsNext: true,
            stepNumber: 0, 
        }
    }

    handleClick(i) {
        const history = this.state.history;
        const current = history[history.length - 1];
        const squares = current.squares.slice();

        if (calculateWinner(squares)) {
            return;
        }

        squares[i] = this.state.xIsNext ? 'X' : 'O';
        this.setState({
            history: history.concat([{
                squares: squares,
            }]),
            xIsNext: !this.state.xIsNext,
        });
    }

    jumpTo(move) {
        const history = this.state.history;
        history.length = move + 1;
        this.setState({
            history: history,
            xIsNext: move%2 === 0? true : false,
        });
    };

    render() {
        const history = this.state.history;
        console.log('history: ', history);
        const current = history[history.length - 1];
        const winner = calculateWinner(current.squares);

        // Writing steps
        const moves = history.map((step, move) => {
            const desc = move? 'Go to move #' + move : 'Go to game start'; // move should be the index
            return (
                <li key={move}>
                    <button onClick={() => this.jumpTo(move)}>
                    {desc}
                    </button>
                </li>
            );
        });

        let status;
        if (winner) {
            status = 'Winner: ' + winner;
        } else {
            status = 'Next player: ' + (this.state.xIsNext ? "X" : "O");
        }

        return (
            <div className="game">
                <div className="game-board">
                    <Board
                        squares={current.squares}
                        onClick={(i) => this.handleClick(i)}
                    />
                </div>
                <div className="game-info">
                    <div>{ status }</div>
                    <ol>{ moves }</ol>
                </div>
            </div>
        );
    }
}

// HELPER: who's winner func
function calculateWinner(squares) {
    // Array contains all the combination of winning possibilities 
    const lines = [
        [0, 1, 2],
        [3, 4, 5],
        [6, 7, 8],
        [0, 3, 6],
        [1, 4, 7],
        [2, 5, 8],
        [0, 4, 8],
        [2, 4, 6],
    ];
    for (let i = 0; i < lines.length; i++) {
        const [a, b, c] = lines[i];
        if (squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
            // return either "X" or "O"
            return squares[a];
        }
    }
    return null;
}

// ========================================

ReactDOM.render(
    <Game />,
    document.getElementById('root')
);

ReactDOM.render(
    <LightningCounterDisplay />,
    document.querySelector("#lightening")
);

ReactDOM.render(
    <TodoList />,
    document.querySelector('#todo')
);
