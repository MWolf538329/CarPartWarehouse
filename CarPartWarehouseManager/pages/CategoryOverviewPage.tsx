import { $DEVCOMP, createEffect, createResource, For, type Component } from 'solid-js';

import Navbar from '../src/Navbar';

import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow
} from "~/components/ui/table"

import { Button } from "~/components/ui/button"
import { style } from 'solid-js/web';

import "../src/style.css";

const [categories] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories").then(body=>body.json()))
  createEffect(() => console.log(categories()))

  function DeleteCategory(categoryID:Number){
    if(confirm("Are you sure you want to delete this category?"))
    {
      fetch(`api.localhost/categories/${categoryID}`, {
        method: "Delete"
      })
    }
  }


const CategoryOverviewPage: Component = () => {
return(
    <div>
      <Navbar />

      <Table>
        <TableHeader>
          <TableRow>
            <TableHead class="tableHead">Name</TableHead>
            <TableHead class="tableHead">Edit</TableHead>
            <TableHead class="tableHead">Delete</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          <For each={categories()}>
            {category => 
              <TableRow>
                <TableCell>{category.name}</TableCell>
                <TableCell><a class="editButton" href='/CategoryEditPage'>Edit</a></TableCell>
                <TableCell><Button class="deleteButton" variant="destructive" onclick={() => DeleteCategory(0)}>Delete</Button></TableCell>
              </TableRow>
            }
          </For>
        </TableBody>
      </Table>
    </div>
)

}

export default CategoryOverviewPage;