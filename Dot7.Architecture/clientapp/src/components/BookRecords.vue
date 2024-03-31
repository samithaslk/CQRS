<template>
    <div class="container-fluid mt-4">
      <h1>Book Records</h1>
 
      <div class="row">
        <div class="col-sm">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Title</th>
                <th>Isbn</th>
                <th>Author</th> 
                <th>&nbsp;</th>
              </tr>
            </thead>
            <tbody>
                <tr v-for="book of records" v-bind:key="book">
                <td>   {{book.title}}</td>
                <td> {{book.isbn}}</td>
                <td> {{book.author}}</td> 
                <td class="text-right">
                  <a href="#" @click.prevent="updateFoodRecord(record)">Edit</a> -
                  <a href="#" @click.prevent="deleteFoodRecord(record.id)">Delete</a>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        <div class="col-sm">
          <div :title="(model.id ? 'Edit Food ID#' + model.id : 'New Food Record')">
            <form @submit.prevent="createFoodRecord">
                <div class="form-group">
  
                <input type="text" class="form-control" id="exampleInputEmail1"  v-model="model.name">
              </div>
              <div class="form-group">
     
                <input type="number" class="form-control" id="exampleInputEmail1"  v-model="model.value">
              </div> 
              <div>
              
                <button type="submit" class="btn btn-primary">Submit</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
    import api from '@/BookRecordsApiService';
  
    export default {
      data() {
        return {
          loading: false,
          records: [],
          model: {}
        };
      },
      async created() {
        this.getAll()
      },
      methods: {
        async getAll() {
          this.loading = true
  
          try {
            this.records = await api.getAll()
          } finally {
            this.loading = false
          }
        },
        async updateFoodRecord(foodRecord) {
          // We use Object.assign() to create a new (separate) instance
          this.model = Object.assign({}, foodRecord)
        },
        async createFoodRecord() {
          const isUpdate = !!this.model.id;
  
          if (isUpdate) {
            await api.update(this.model.id, this.model)
          } else {
            await api.create(this.model)
          }
  
          // Clear the data inside of the form
          this.model = {}
  
          // Fetch all records again to have latest data
          await this.getAll()
        },
        async deleteFoodRecord(id) {
          if (confirm('Are you sure you want to delete this record?')) {
            // if we are editing a food record we deleted, remove it from the form
            if (this.model.id === id) {
              this.model = {}
            }
  
            await api.delete(id)
            await this.getAll()
          }
        }
      }
    }
  </script>