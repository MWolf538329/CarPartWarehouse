import { $DEVCOMP, createEffect, createResource, createSignal, For, type Component } from 'solid-js';

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

import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from "~/components/ui/dialog"
import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"
import { reload, Route } from '@solidjs/router';

//import "../src/style.css";

const [categories] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories").then(body=>body.json()))
  createEffect(() => console.log(categories()))

const [value, setValue] = createSignal<string>("")

  function CreateCategory(){
    const categoryName = value()
    createEffect(() => console.log(value()))
    if(categoryName != ""){
      fetch(`https://api.localhost/categories?name=${categoryName}`, {
        method: "POST"
      })
      setTimeout(() => {
        close()
      }, 1000);
    }
  }

  function DeleteCategory(categoryID:Number){
    if(confirm("Are you sure you want to delete this category?"))
    {
      fetch(`https://api.localhost/categories/${categoryID}`, {
        method: "Delete"
      })
    }
  }


const CategoryOverviewPage: Component = () => {
return(
    <div>
      <Navbar />

      <Dialog>
        <DialogTrigger>Create Category</DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Create Category</DialogTitle>
            <DialogDescription> Create a new category here </DialogDescription>
          </DialogHeader>
          <div>
            <TextField>
              <TextFieldLabel>Name: </TextFieldLabel>
              <TextFieldInput 
                value={value()}
                oninput={(e) => {
                  setValue(e.target.value)
                }}
               type='text'
               required/>
            </TextField>
          </div>
          <DialogFooter>
            <Button type='submit' onclick={CreateCategory}>Create</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>


      <div class="mt-5">
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
      
    </div>
)

}

export default CategoryOverviewPage;