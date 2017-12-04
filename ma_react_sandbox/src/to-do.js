import React from 'react';
// import ReactDOM from 'react-dom';

class TodoList extends React.Component {
    constructor(props, context) {
        super(props, context);
        this.state = {
            items: []
        }

        this.add = this.add.bind(this);
        this.deleteItem = this.deleteItem.bind(this);
    }

    add(e) {
        let itemArr = this.state.items;
        if(this._inputEl.value !== "") {
            itemArr.unshift({
                text: this._inputEl.value,
                key: Date.now()
            })
        }
        this.setState({items: itemArr});
        this._inputEl.value = "";
        e.preventDefault();
    }

    deleteItem(key) {
        let filteredItems = this.state.items.filter(i => {return (i.key !== key)});
        this.setState({
            items: filteredItems
        });
    }

    render() {
        let inputStyle = {
            margin: "5px auto",
            padding: "10px 5px",
            width: "150px",
        }
        let buttonStyle = {
            marginLeft: "5px",
            padding: "10px 5px",
            width: "50px",
            backgroundColor: "gold",
            fontWeight: "bold",
        }

        return (
            <div className="todoListMain">
                <div className="header">
                    <form onSubmit={this.add}>
                        <input 
                            placeholder="enter task"
                            ref={(a) => this._inputEl = a}
                            style={inputStyle}>
                        </input>
                        <button type="submit" style={buttonStyle}>add</button>
                    </form>
                </div>
                <ListItem items={this.state.items}
                          delete={this.deleteItem} />
            </div>
        )
    }
}

class ListItem extends React.Component {
    constructor(props){
        super(props);
        this.delete = this.delete.bind(this);
    }

    delete(key) {
        this.props.delete(key);
    }

    render() {
        console.log(this.props.items);
        let listStyles = {
            width: "250px",
            border: "2px solid blue",
            borderRadius: "5px",
            listStyle: "none",
            padding: "2px 5px",
            marginTop: "5px",
        }

        let ulStyle = {
            padding: "0",
        }

        const itemLi = this.props.items.map(i => {
            return (
                <li key={i.key}
                    onClick={(e) => this.props.delete(i.key, e)}
                    style={listStyles}>
                    {i.text}
                </li>
            )
        })
        return (
            <ul style={ulStyle}>{itemLi}</ul>
        )
    }
}


export default TodoList;