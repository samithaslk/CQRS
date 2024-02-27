<template>
    <h1>Books</h1>

    <table class="table table-stripped">
        <thead>
            <tr>
                <td>
                    <div class="d-flex flex-row">

                        <input class="form-control m-2"
                               v-model="TitleFilter"
                               v-on:keyup="FilterFn()"
                               placeholder="Filter">

                        <button type="button" class="btn btn-light"
                                @click="sortResult('title',true)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                            </svg>
                        </button>

                        <button type="button" class="btn btn-light"
                                @click="sortResult('title',false)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                            </svg>
                        </button>

                    </div>
                    Title
                </td>
                <td>
                    <div class="d-flex flex-row">

                        <input class="form-control m-2"
                               v-model="IsbnFilter"
                               v-on:keyup="FilterFn()"
                               placeholder="Filter">

                        <button type="button" class="btn btn-light"
                                @click="sortResult('isbn',true)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                            </svg>
                        </button>

                        <button type="button" class="btn btn-light"
                                @click="sortResult('isbn',false)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                            </svg>
                        </button>

                    </div>
                    Isbn
                </td>
                <td>
                    <div class="d-flex flex-row">

                        <input class="form-control m-2"
                               v-model="AuthorFilter"
                               v-on:keyup="FilterFn()"
                               placeholder="Filter">

                        <button type="button" class="btn btn-light"
                                @click="sortResult('author',true)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-down-square-fill" viewBox="0 0 16 16">
                                <path d="M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v5.793l2.146-2.147a.5.5 0 0 1 .708.708l-3 3a.5.5 0 0 1-.708 0l-3-3a.5.5 0 1 1 .708-.708L7.5 10.293V4.5a.5.5 0 0 1 1 0z" />
                            </svg>
                        </button>

                        <button type="button" class="btn btn-light"
                                @click="sortResult('author',false)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-up-square-fill" viewBox="0 0 16 16">
                                <path d="M2 16a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2zm6.5-4.5V5.707l2.146 2.147a.5.5 0 0 0 .708-.708l-3-3a.5.5 0 0 0-.708 0l-3 3a.5.5 0 1 0 .708.708L7.5 5.707V11.5a.5.5 0 0 0 1 0z" />
                            </svg>
                        </button>

                    </div>
                    Author
                </td>
            </tr>
        </thead>
        <tbody>
            <tr v-for="book of books" v-bind:key="book">
                <td>
                    {{book.title}}
                </td>
                <td>
                    {{book.isbn}}
                </td>
                <td>
                    {{book.author}}
                </td>
            </tr>
        </tbody>
    </table>

</template>

<script>
    import axios from "axios";

    export default {
        name: 'fetchBooks',
        data() {
            return {
                books: [],
                TitleFilter:"",
                IsbnFilter:"",
                AuthorFilter:"",
                booksWithoutFilter: []
            }
        },
        methods: {
            getBooks() {
                axios.get('https://localhost:7172/book')
                    .then((response) => {
                        this.books = response.data;
                        this.booksWithoutFilter = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            FilterFn() {
                var titleFilter = this.TitleFilter;
                var isbnFilter = this.IsbnFilter;
                var authorFilter = this.AuthorFilter;

                this.books = this.booksWithoutFilter.filter(
                    function (el) {
                        return el.title.toString().toLowerCase().includes(
                            titleFilter.toString().trim().toLowerCase()
                        ) &&
                            el.isbn.toString().toLowerCase().includes(
                                isbnFilter.toString().trim().toLowerCase()
                            )
                            &&
                            el.author.toString().toLowerCase().includes(
                                authorFilter.toString().trim().toLowerCase()
                            )
                    });
            },
            sortResult(prop, asc) {
                this.books = this.booksWithoutFilter.sort(function (a, b) {

                    if (asc) {
                        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
                    }
                    else {
                        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
                    }
                });
            }
        },
        mounted() {
            this.getBooks();
        }
    }
</script>