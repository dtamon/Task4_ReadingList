import React, { Component } from 'react';
import { MdDragHandle } from 'react-icons/md'
import { DragDropContext, Droppable, Draggable} from 'react-beautiful-dnd';

export class Book extends Component {

    constructor(props) {
        super(props);
        this.state = {
            books: [],
            authors: [],
            modalTitle: "",
            id: 0,
            title: "",
            authorId: 0,
            authorName: "",
            isRead: false,
            position: 0,

            titleError: "",
            authorError: "",

            titleFilter: "",
            authorNameFilter: "",
            isReadFilter: "",
            booksWithoutFilter: [],
        };
    }

    refreshList() {
        fetch('book', {method: 'GET'})
        .then(response => response.json())
        .then(data => {
            this.setState({ books: data, booksWithoutFilter: data });
        });
        fetch('author', {method: 'GET'})
        .then(response => response.json())
        .then(data => {
            this.setState({ authors: data });
        });
    }

    componentDidMount() {
        this.refreshList();
    }

    filterData() {
        var titleFilter = this.state.titleFilter;
        var authorNameFilter = this.state.authorNameFilter;
        var isReadFilter = this.state.isReadFilter;

        var filteredData = this.state.booksWithoutFilter.filter(
            function (el) {
                return el.title.toString().toLowerCase().includes(
                    titleFilter.toString().trim().toLowerCase()
                ) &&
                el.authorName.toString().toLowerCase().includes(
                authorNameFilter.toString().trim().toLowerCase()
                ) &&
                el.isRead.toString().toLowerCase().includes(
                isReadFilter.toString().trim().toLowerCase()
                )
            }
        );
        this.setState({books: filteredData});
    }
    sortResult(prop, asc) {
        var sortedData = this.state.booksWithoutFilter.sort(function (a, b) {
            if (asc) {
                return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
            }
            else {
                return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
            }
        });
        this.setState({ books: sortedData });
        this.filterData();
    }

    changeNameFilter = (e) => {
        this.state.titleFilter = e.target.value;
        this.filterData();
    }
    changeAuthorNameFilter = (e) => {
        this.state.authorNameFilter = e.target.value;
        this.filterData();
    }
    changeIsReadFilter = (e) => {
        this.state.isReadFilter = e.target.value;
        this.filterData();
    }

    changeBookTitle = (e) => {
        this.setState({ title: e.target.value });
    }
    changeAuthor = (e) => {
        this.setState({ authorId: e.target.value,});
    }
    changeIsRead = (e) => {
        this.setState({ isRead: e.target.checked });
    }

    addClick(){
        this.setState({
            modalTitle: "Add book",
            id: 0,
            title: "",
            authorId: 0,
            authorName: "",
            isRead: false,
            position: 0,
            titleError: "",
            authorError: "",
        });
    }
    editClick(book){
        this.setState({
            modalTitle: "Edit book",
            id: book.id,
            title: book.title,
            authorId: book.authorId,
            authorName: book.authorName,
            isRead: book.isRead,
            position: book.position,
            titleError: "",
            authorError: "",
        });
    }

    createClick() {
        this.setState({ titleError: "", authorError: ""})
        fetch('book', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                title: this.state.title,
                authorId: this.state.authorId,
                authorName: this.state.authorName,
                isRead: this.state.isRead,
                position: this.state.position,
            })
        })
            .then(res => res.json())
            .then((result) => {
                this.refreshList()
                result.errors !== undefined ? 
                    this.setState({ titleError: result.errors.Title !== undefined ? result.errors.Title[0] : "",
                                 authorError: result.errors.AuthorId !== undefined ? result.errors.AuthorId[0] : ""})
                                 : alert(result)
            }, (error) => {
                alert('Failed');
            })   
    }
    updateClick() {
        this.setState({ titleError: "", authorError: ""})
        fetch('book/' + this.state.id, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: this.state.id,
                title: this.state.title,
                authorId: this.state.authorId,
                authorName: this.state.authorName,
                isRead: this.state.isRead,
                position: this.state.position
            })
        })
            .then(res => res.json())
            .then((result) => {
                this.refreshList();
                result.errors !== undefined ? 
                    this.setState({ titleError: result.errors.Title !== undefined ? result.errors.Title[0] : "",
                                 authorError: result.errors.AuthorId !== undefined ? result.errors.AuthorId[0] : ""})
                                 : alert(result)
            }, (error) => {
                alert('Failed');
            })
    }
    deleteClick(id) {
        if (window.confirm('Are you sure?')) {
            fetch('book/' + id, {
                method: 'DELETE',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    this.refreshList();
                }, (error) => {
                    alert('Failed');
                })
        }
    }

    saveClick() {
        if (window.confirm("Do you want to save the order?")) {
            fetch('book/saveOrder', {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(this.state.books)
            })
                .then(res => res.json())
                .then((result) => {
                    alert(result);
                    this.refreshList();
                }, (error) => {
                    alert('Failed');
                })
        }
    }

    onDragEnd = (e) => {
        if(!e.destination) return ;
        let tempBook = [...this.state.books]
        let [selectedRow] = tempBook.splice(e.source.index, 1)
        tempBook.splice(e.destination.index, 0, selectedRow);
        this.setState({books: tempBook});
    }

    render() {
        const {
            books,
            authors,
            modalTitle,
            id,
            title,
            authorId,
            isRead,
            titleError,
            authorError,
        } = this.state;
        return (
            <div>
                <button type="button"
                    className="btn btn-primary m-2 float-end"
                    data-bs-toggle="modal"
                    data-bs-target="#exampleModal"
                    onClick={() => this.addClick()}>
                    Add book
                </button>
                <button type="button"
                    className="btn btn-primary m-2 float-end"
                    onClick={() => this.saveClick()}>
                    Save Order
                </button>
                <h1 className='d-flex justify-content-left m-3'>Books List</h1>
                <DragDropContext onDragEnd={(results) => this.onDragEnd(results)}>
                    <table className="table table-striped">
                        <thead>
                            <tr>
                                <th></th>
                                <th>
                                    <div className="d-flex flex-row">
                                        <button type="button" className="btn btn-light"
                                                onClick={() => this.sortResult('position', true)}>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                                    <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                                                </svg>
                                            </button>

                                            <button type="button" className="btn btn-light"
                                                onClick={() => this.sortResult('position', false)}>
                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                                    <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                                                </svg>
                                            </button>
                                    </div>
                                    Position
                                </th>
                                <th>
                                    <div className="d-flex flex-row">
                                        <input className="form-control m-2"
                                            onChange={this.changeNameFilter}
                                            placeholder="Filter" />

                                        <button type="button" className="btn btn-light"
                                            onClick={() => this.sortResult('title', true)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                                            </svg>
                                        </button>

                                        <button type="button" className="btn btn-light"
                                            onClick={() => this.sortResult('title', false)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                                <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                                            </svg>
                                        </button>

                                    </div>
                                    Title
                                </th>
                                <th>
                                    <div className="d-flex flex-row">
                                        <input className="form-control m-2"
                                            onChange={this.changeAuthorNameFilter}
                                            placeholder="Filter" />

                                        <button type="button" className="btn btn-light"
                                            onClick={() => this.sortResult('authorName', true)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                                            </svg>
                                        </button>

                                        <button type="button" className="btn btn-light"
                                            onClick={() => this.sortResult('authorName', false)}>
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                                <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                                            </svg>
                                        </button>
                                    </div>
                                    Author
                                </th>
                                <th>
                                <div className="d-flex flex-row">
                                    <select className="form-select m-2"
                                            onChange={this.changeIsReadFilter}>
                                                <option value="">All</option>
                                                <option value="false">To Read</option>
                                                <option value="true">Already Read</option>  
                                    </select>
                                </div>
                                    Options
                                </th>
                            </tr>
                        </thead>

                        <Droppable droppableId='tbody'>
                            {(provider) => (
                                    <tbody ref={provider.innerRef} {...provider.droppableProps} >
                                        {books.map((book, index) =>

                                            <Draggable key={book.id} draggableId={book.title} index={index}>
                                                {(provider) => (
                                                    <tr key={book.id} ref={provider.innerRef} {...provider.draggableProps} >
                                                        <td style={{ width: 50 }} {...provider.dragHandleProps}>
                                                            <MdDragHandle size={25} />
                                                        </td>
                                                        <td>{book.position}</td>
                                                        <td>{book.title}</td>
                                                        <td>{book.authorName}</td>
                                                        <td>
                                                            <button type="button"
                                                                className="btn btn-light mr-1"
                                                                data-bs-toggle="modal"
                                                                data-bs-target="#exampleModal"
                                                                onClick={() => this.editClick(book)}>
                                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-pencil-square" viewBox="0 0 16 16">
                                                                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                                                    <path fillRule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                                                </svg>
                                                            </button>

                                                            <button type="button"
                                                                className="btn btn-light mr-1"
                                                                onClick={() => this.deleteClick(book.id)}>
                                                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-trash-fill" viewBox="0 0 16 16">
                                                                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                                                </svg>
                                                            </button>

                                                        </td>
                                                    </tr>
                                                )}
                                            </Draggable>
                                        )}
                                        {provider.placeholder}
                                    </tbody>
                                )}
                        </Droppable>
                    </table>
                </DragDropContext>
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-hidden="true">
                    <div className="modal-dialog modal-lg modal-dialog-centered">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h5 className="modal-title">{modalTitle}</h5>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"
                                ></button>
                            </div>

                            <div className="modal-body">
                                <div className="input-group mb-1">
                                    <span className="input-group-text">Title</span>
                                    <input type="text" className="form-control"
                                        value={title}
                                        onChange={this.changeBookTitle} />
                                </div>
                                <span className="input-group mb-3 text-danger">{titleError}</span>

                                <div className="input-group mb-1">
                                    <span className="input-group-text">Author</span>
                                    <select className="form-select"
                                                onChange={this.changeAuthor}
                                                value={authorId}>
                                                    <option value="" hidden>-- Select Author --</option>
                                                {authors.map(author =>
                                                    <option key={author.id} value={author.id} >
                                                        {author.firstName} {author.lastName}
                                                    </option>)}
                                            </select>
                                </div>
                                <span className="input-group mb-3 text-danger">{authorError}</span>

                                <div className="input-group mb-3">
                                    <span className="input-group-text">Is Read</span>
                                    <div className='form-control'>
                                        <input type="checkbox" className='form-check-input float-start'
                                                checked={isRead}
                                                onChange={this.changeIsRead} />
                                    </div>
                                    
                                                         
                                </div>

                                {id === 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.createClick()}
                                    >Create</button>
                                    : null}

                                {id !== 0 ?
                                    <button type="button"
                                        className="btn btn-primary float-start"
                                        onClick={() => this.updateClick()}
                                    >Update</button>
                                    : null}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}