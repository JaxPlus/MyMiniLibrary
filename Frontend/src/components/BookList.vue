<script setup lang="ts">
import Book from "../Models/Book.ts";
import BookComp from "./BookComp.vue"
import { onMounted, ref } from "vue";
import Menu from "./Menu.vue";

const books = ref<Book[] | undefined>();
const filteredBooks = ref<Book[]>();
const query = ref("");
const filter = ref("Nazwa");

onMounted(async () => {
  await getBooks();
})

async function getBooks() {
  books.value = await fetch("http://localhost:5296/api/book", {
    method: "GET",
  })
      .then((res) => res.json())
      .catch((error) => console.error(error));

  books.value = books.value?.sort((a, b) => a.price <= b.price ? 1 : -1);
}

function filterResults() {
  filteredBooks.value = books.value?.filter((book) => {
    const queryLower = query.value.toLowerCase();
    
    switch (filter.value) {
      case "Nazwa":
        return book.name.toLowerCase().includes(queryLower);
      case "Autor":
        return book.authorName.toLowerCase().includes(queryLower);
      case "Wydawnictwo":
        return book.publishingHouseName.toLowerCase().includes(queryLower);
      case "Seria":
        return book.seriesName.toLowerCase().includes(queryLower);
    }
  });
}
</script>

<template>
  <div class="container">
    <Menu />
    <div class="search-queries-container">
      <input @input="filterResults()" v-model="query" class="search-input" type="search" placeholder="Nazwa..." autocomplete="off" />
      <select v-model="filter" class="search-input">
        <option selected>Nazwa</option>
        <option>Autor</option>
        <option>Wydawnictwo</option>
        <option>Seria</option>
      </select>
    </div>
    <div class="book-list">
      <BookComp v-if="filteredBooks" v-for="book in filteredBooks" :key="book.bookId" :book="book" />
      <BookComp v-else v-for="book in books" :key="book.name" :book="book" />
    </div>
  </div>
</template>

<style scoped>
.search-queries-container {
  position: absolute;
  top: 0;
}

.search-input {
  margin: 20px;
  padding: 10px;
  border-radius: 5px;
  border: #1e1c1c 1px solid;
}

.container {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.search-queries-container:focus {
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