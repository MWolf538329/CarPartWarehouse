import { createEffect, createResource, createSignal, For, type Component } from 'solid-js';

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

import { showToast, Toaster } from '~/components/ui/toast';

//import "../src/style.css";

const [categories] = createResource<Category[] | undefined>(() => fetch("https://api.localhost/categories").then(body=>body.json()))
createEffect(() => console.log(categories()))

const [value, setValue] = createSignal("")
const [responseCode, setResponseCode] = createSignal(0)
const [isOpen, setIsOpen] = createSignal(false)
let isClosed;

const handleOpenChange = (open:boolean) => {
  setIsOpen(open)
  isClosed = !isOpen()
  console.log(isClosed)
  if (isClosed) {
      // Only reload when the dialog is closed
      location.reload();
  }
}

function CreateCategory(){
  console.log(value())

  if(value() !== ""){
    fetch(`https://api.localhost/categories?name=${value()}`, {
      method: "Post"
    }).then((response) => {
      //console.log("Response:", response);
      const statusCode = Number.parseInt(response.status.toString());
      setResponseCode(statusCode);
      console.log("Updated responseCode:", responseCode());

      switch(responseCode().toString().substring(0, 2)){
        case "20":
          showToast({ title: "Category Added", variant: "success" })
          break;
        
        case "40":
          showToast({ title: "Failed!", variant: "error" })
          break;

        case "0":
          showToast({ title: "Debug", variant: "warning" })
          break;
      }
    })
  }
}

function DeleteCategory(categoryID:Number){
  if(confirm("Are you sure you want to delete this category?"))
  {
    fetch(`https://api.localhost/categories/${categoryID}`, {
      method: "Delete"
    })
    setTimeout(() => {
      location.reload()
    }, 500);
  }
}

const CategoryOverviewPage: Component = () => {
  return(
    <div>
      <Navbar />

      <Dialog onOpenChange={handleOpenChange}>
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
                onChange={e => setValue(e.target.value) }
                type='text'
                required />
            </TextField>
          </div>
          <DialogFooter>
            <Button type='submit' onClick={() => CreateCategory()}>Create</Button>
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
                  <TableCell><Button class="deleteButton" variant="destructive" onClick={() => DeleteCategory(category.id)}>Delete</Button></TableCell>
                </TableRow>
              }
            </For>
          </TableBody>
        </Table>
      </div>
      
      <Toaster />
    </div>
  )
}

export default CategoryOverviewPage