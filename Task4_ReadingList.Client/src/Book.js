import React, { Component } from 'react';

export class Book extends Component {
    static displayName = Book.name;

    constructor(props) {
        super(props);
        this.state = { books: [], loading: true };
    }

    componentDidMount() {
        this.getBooks();
    }

    static renderBooksTable(books) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Is Read</th>
                    </tr>
                </thead>
                <tbody>
                    {books.map(book =>
                        <tr key={book.id}>
                            <td>{book.name}</td>
                            <td>{book.authorName}</td>
                            <td><input type="checkbox" checked={book.isRead} id="rowcheck{book.id}" /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
            : Book.renderBooksTable(this.state.books);

        return (
            <div>
                <h1 id="tabelLabel" >Reading List</h1>
                {contents}
            </div>
        );
    }

    async getBooks() {
        const response = await fetch('book', {method: 'GET'});
        const data = await response.json();
        this.setState({ books: data, loading: false });
    }
}