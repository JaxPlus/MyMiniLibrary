<script setup lang="ts">
import Book from "../Models/Book.ts";
import BookComp from "./BookComp.vue"
import {onMounted, ref} from "vue";

let books = ref<Book[] | undefined>();

onMounted(async () => {
  await getBooks()
})

async function getBooks() {
  books.value = await fetch("http://localhost:5296/api/book", {
    method: "GET",
  }).then((res) => {
    // console.log(res.json())
    return res.json();
  })
      .catch((error) => console.error(error));

  books.value = books.value?.sort((a, b) => a.price <= b.price ? 1 : -1);
}
</script>

<template>
  <div class="book-list">
    <BookComp v-for="book in books" :key="book.bookId" :book="book" />
  </div>
</template>

<style scoped>
.book-list {
  display: flex;
  flex-direction: row;
  padding: 0 10px 0 10px;
  align-items: flex-end;
}
</style>