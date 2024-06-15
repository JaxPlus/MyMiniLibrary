<script setup lang="ts">
import Book from "../Models/Book.ts";
import BookComp from "./BookComp.vue"
import { onMounted, ref } from "vue";

const books = ref<Book[] | undefined>();
const filteredBooks = ref<Book[]>();
const query = ref("");

onMounted(async () => {
  await getBooks();
})

async function getBooks() {
  books.value = await fetch("http://localhost:5296/api/book", {
    method: "GET",
  }).then((res) => {
    return res.json();
  })
      .catch((error) => console.error(error));

  books.value = books.value?.sort((a, b) => a.price <= b.price ? 1 : -1);
}

function filterResults() {
  filteredBooks.value = books.value?.filter((book) => book.name.toLowerCase().includes(query.value.toLowerCase()));
}

/** @todo Create search by author and by title */
</script>

<template>
  <div class="container">
    <input @input="filterResults()" v-model="query" class="search-input" type="search" placeholder="Nazwa..." autocomplete="off" />
    <div class="book-list">
      <BookComp v-if="filteredBooks" v-for="book in filteredBooks" :key="book.bookId" :book="book" />
      <BookComp v-else v-for="book in books" :key="book.name" :book="book" />
    </div>
  </div>
</template>

<style scoped>
.search-input {
  margin: 20px;
  padding: 10px;
  border-radius: 5px;
  border: #1e1c1c 1px solid;
  position: absolute;
  top: 0;
}

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.search-input:focus {
  outline: #535bf2 2px solid;
}

.book-list {
  margin-top: 5rem;
  display: grid;
  padding: 0 10px 0 10px;
  align-items: flex-end;
  grid-template-rows: auto auto auto auto;
  grid-template-columns: auto auto auto auto auto auto auto auto auto auto;
}
</style>