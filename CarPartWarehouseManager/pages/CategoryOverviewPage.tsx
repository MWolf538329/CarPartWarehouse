import { createEffect, createResource, createSignal, For, type Component } from 'solid-js';

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

import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbSeparator
} from "~/components/ui/breadcrumb"

import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuDescription,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLabel,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"

import { Navigate, Route, useNavigate } from '@solidjs/router';

import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"

import { showToast, Toaster } from '~/components/ui/toast';

import "../src/style.css";
import { useRoute } from '@solidjs/router/dist/routing';

const [categories] = createResource<Category[] | undefined>(() => fetch(`https://api.localhost/categories`).then(body=>body.json()))

const [newCategory, setNewCategory] = createSignal("")
const [updatedCategory, setUpdatedCategory] = createSignal("")
const [responseCode, setResponseCode] = createSignal(0)
const [isOpen, setIsOpen] = createSignal(false)
let isClosed;

const handleOpenChange = (open:boolean) => {
  setIsOpen(open)
  isClosed = !isOpen()
  if (isClosed) {
      // Only reload when the dialog is closed
      location.reload();
  }
}

function CreateCategory(){
  if(newCategory() !== ""){
    fetch(`https://api.localhost/categories?name=${newCategory()}`, {
      method: "POST"
    }).then((response) => {
      const statusCode = Number.parseInt(response.status.toString());
      setResponseCode(statusCode);
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

function UpdateCategory(categoryID:Number){
  if(updatedCategory() !== ""){
    fetch(`https://api.localhost/categories/${categoryID}?name=${updatedCategory()}`, {
      method: "PUT"
    }).then((response) => {
      const statusCode = Number.parseInt(response.status.toString());
      setResponseCode(statusCode);
      switch(responseCode().toString().substring(0, 2)){
        case "20":
          showToast({ title: "Category Updated", variant: "success" })
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
      method: "DELETE"
    })
    setTimeout(() => {
      location.reload()
    }, 500);
  }
}

function CategoryDetails(categoryID:Number){
  localStorage.CategoryID = categoryID
  localStorage.setItem("CategoryID", categoryID.toPrecision())
  //setTimeout(() => navigate("/CategoryPage"), 400)
}

const CategoryOverviewPage: Component = () => {
  return(
    <div>
      {/* Breadcrumb Navigation */}
      <Breadcrumb>
        <BreadcrumbList>
          <BreadcrumbItem>
            <BreadcrumbLink href="/" current>Home</BreadcrumbLink>
          </BreadcrumbItem>
          <BreadcrumbSeparator />
        </BreadcrumbList>
      </Breadcrumb>
      {/* --------------------- */}

      {/* Create new Category Dialog */}
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
                onChange={e => setNewCategory(e.target.value)}
                type='text'
                required />
            </TextField>
          </div>
          <DialogFooter>
            <Button type='submit' onClick={() => CreateCategory()}>Create</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
      {/* ------------------ */}

      {/* Category Table */}
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
                  <TableCell>
                    {category.name}

                    {/* <a href='/CategoryPage/{category.id}'>{category.name}</a>
                    <Button variant={'link'} onclick={() => CategoryDetails(category.id)}></Button> */}
                  </TableCell>
                  <TableCell>

                    {/* Edit Category Dialog */}
                    <Dialog onOpenChange={handleOpenChange}>
                      <DialogTrigger class='editButton'>Edit</DialogTrigger>
                      <DialogContent>
                        <DialogHeader>
                          <DialogTitle>Update Category</DialogTitle>
                          <DialogDescription> Update category: {category.name} here </DialogDescription>
                        </DialogHeader>
                        <div>
                          <TextField>
                            <TextFieldLabel>Name: </TextFieldLabel>
                            <TextFieldInput
                              value={category.name}
                              onChange={e => setUpdatedCategory(e.target.value)}
                              type='text'
                              required />
                          </TextField>
                        </div>
                        <DialogFooter>
                          <Button type='submit' onClick={() => UpdateCategory(category.id)}>Update</Button>
                        </DialogFooter>
                      </DialogContent>
                    </Dialog>
                    {/* -------------------- */}

                  </TableCell>
                  <TableCell><Button class="deleteButton" variant="destructive" onClick={() => DeleteCategory(category.id)}>Delete</Button></TableCell>
                </TableRow>
              }
            </For>
          </TableBody>
        </Table>
      </div>
      {/* ----------- */}
      
      <Toaster />
    </div>
  )
}

export default CategoryOverviewPage