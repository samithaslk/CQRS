 
import axios from 'axios'

const client = axios.create({
  baseURL: 'https://localhost:7172/',
  json: true
})

export default {
  async execute(method, resource, data) {
    
    return client({
      method,
      url: resource,
      data 
    }).then(req => {
      return req.data
    })
  },
  getAll() {
    return this.execute('get', 'book')
  },
  create(data) {
    return this.execute('post', '/', data)
  },
  update(id, data) {
    return this.execute('put', `/${id}`, data)
  },
  delete(id) {
    return this.execute('delete', `/${id}`)
  }
}