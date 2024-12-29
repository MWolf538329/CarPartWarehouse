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

import { TextField, TextFieldInput, TextFieldLabel } from "~/components/ui/text-field"

import { showToast, Toaster } from '~/components/ui/toast';

import "../src/style.css";

import { useNavigate } from '@solidjs/router';

const CategoryID = Number(localStorage.getItem("CategoryID"))

const [category] = createResource<Category | undefined>(() => fetch(`https://api.localhost/categories/${CategoryID}`).then(body=>body.json()))

const [newSubcategory, setNewSubcategory] = createSignal("")
const [updatedSubcategory, setUpdatedSubcategory] = createSignal("")
const [responseCode, setResponseCode] = createSignal(0)
const [isOpen, setIsOpen] = createSignal(false)
let isClosed;

//const navigate = useNavigate()

const handleOpenChange = (open:boolean) => {
  setIsOpen(open)
  isClosed = !isOpen()
  if (isClosed) {
      // Only reload when the dialog is closed
      location.reload();
  }
}

function CreateSubcategory(){
  if(newSubcategory() !== ""){
    fetch(`https://api.localhost/categories/${CategoryID}/subcategories?name=${newSubcategory()}`, {
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

function UpdateSubcategory(subcategoryID:Number){
  if(updatedSubcategory() !== ""){
    fetch(`https://api.localhost/categories/${category()?.id}/subcategories/${subcategoryID}?name=${updatedSubcategory()}`, {
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

function DeleteSubcategory(categoryID:Number){
  if(confirm("Are you sure you want to delete this category?"))
  {
    fetch(`https://api.localhost/categories/${category()?.id}/subcategories/${categoryID}`, {
      method: "DELETE"
    })
    setTimeout(() => {
      location.reload()
    }, 500);
  }
}

function SubcategoryDetails(categoryID:Number){
  localStorage.CategoryID = categoryID
  localStorage.setItem("CategoryID", categoryID.toPrecision())
  //setTimeout(() => navigate("/CategoryPage"), 400)
}

const CategoryPage: Component = () => {
  return(
    <div>
      {/* Breadcrumb Navigation */}
      <Breadcrumb>
        <BreadcrumbList>
          <BreadcrumbItem>
            <BreadcrumbLink href="/">Home</BreadcrumbLink>
          </BreadcrumbItem>
          <BreadcrumbSeparator />
          <BreadcrumbItem>
            <BreadcrumbLink current>{category()?.name}</BreadcrumbLink>
          </BreadcrumbItem>
        </BreadcrumbList>
      </Breadcrumb>
      {/* --------------------- */}

      {/* Create new Category Dialog */}
      <Dialog onOpenChange={handleOpenChange}>
        <DialogTrigger>Create Subcategory</DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Create Subcategory</DialogTitle>
            <DialogDescription> Create a new category here </DialogDescription>
          </DialogHeader>
          <div>
            <TextField>
              <TextFieldLabel>Name: </TextFieldLabel>
              <TextFieldInput
                onChange={e => setNewSubcategory(e.target.value)}
                type='text'
                required />
            </TextField>
          </div>
          <DialogFooter>
            <Button type='submit' onClick={() => CreateSubcategory()}>Create</Button>
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
            <For each={category()?.subcategories}>
              {subcategory => 
                <TableRow>
                  <TableCell>{subcategory.name}</TableCell>
                  <TableCell>

                    {/* Edit Category Dialog */}
                    <Dialog onOpenChange={handleOpenChange}>
                      <DialogTrigger class='editButton'>Edit</DialogTrigger>
                      <DialogContent>
                        <DialogHeader>
                          <DialogTitle>Update Subcategory</DialogTitle>
                          <DialogDescription> Update subcategory: {subcategory.name} here </DialogDescription>
                        </DialogHeader>
                        <div>
                          <TextField>
                            <TextFieldLabel>Name: </TextFieldLabel>
                            <TextFieldInput
                              value={subcategory.name}
                              onChange={e => setUpdatedSubcategory(e.target.value)}
                              type='text'
                              required />
                          </TextField>
                        </div>
                        <DialogFooter>
                          <Button type='submit' onClick={() => UpdateSubcategory(subcategory.id)}>Update</Button>
                        </DialogFooter>
                      </DialogContent>
                    </Dialog>
                    {/* -------------------- */}

                  </TableCell>
                  <TableCell><Button class="deleteButton" variant="destructive" onClick={() => DeleteSubcategory(subcategory.id)}>Delete</Button></TableCell>
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

export default CategoryPage