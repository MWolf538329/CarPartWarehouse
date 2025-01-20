import { createResource, createSignal, For, type Component } from 'solid-js';

import {
  Table,
  TableBody,
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

import { useNavigate, reload } from '@solidjs/router';

import { Flex } from '~/components/ui/flex';

const CategoryPage: Component = () => {
  const navigate = useNavigate()

  const SessionToken = String(sessionStorage.getItem("SessionToken"))
  if (SessionToken.length == 0) {
    navigate("/LoginPage")
  }

  const CategoryID = Number(sessionStorage.getItem("CategoryID"))
  const [category, { refetch }] = createResource<Category | undefined>(() => fetch(`http://api.localhost/categories/${CategoryID}`).then(body => body.json()))
  const [newSubcategory, setNewSubcategory] = createSignal("")
  const [updatedSubcategory, setUpdatedSubcategory] = createSignal("")
  const [responseCode, setResponseCode] = createSignal(0)
  const [isOpen, setIsOpen] = createSignal(false)

  let isClosed;

  const handleOpenChange = (open: boolean) => {
    setIsOpen(open)
    isClosed = !isOpen()
    if (isClosed) {
      // Only reload when the dialog is closed
      refetch();
    }
  }

  function CreateSubcategory() {
    if (newSubcategory() !== "") {
      fetch(`http://api.localhost/categories/${category()?.id}/subcategories?name=${newSubcategory()}`, {
        method: "POST"
      }).then((response) => {
        const statusCode = Number.parseInt(response.status.toString());
        setResponseCode(statusCode);
        switch (responseCode().toString().substring(0, 2)) {
          case "20":
            showToast({ title: "Subcategory Added", variant: "success" })
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

  function UpdateSubcategory(subcategoryID: number) {
    if (updatedSubcategory() !== "") {
      fetch(`http://api.localhost/categories/${category()?.id}/subcategories/${subcategoryID}?name=${updatedSubcategory()}`, {
        method: "PUT"
      }).then((response) => {
        const statusCode = Number.parseInt(response.status.toString());
        setResponseCode(statusCode);
        switch (responseCode().toString().substring(0, 2)) {
          case "20":
            showToast({ title: "Subcategory Updated", variant: "success" })
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

  function DeleteSubcategory(subcategoryID: number) {
    if (confirm("Are you sure you want to delete this subcategory?")) {
      fetch(`http://api.localhost/categories/${category()?.id}/subcategories/${subcategoryID}`, {
        method: "DELETE"
      }).then(() => {
        refetch()
      })
    }
  }

  function SubcategoryDetails(subcategoryID: number) {
    sessionStorage.SubcategoryID = subcategoryID
    sessionStorage.setItem("SubcategoryID", subcategoryID.toPrecision())
    setTimeout(() => navigate(`/categorypage/${CategoryID}/subcategorypage/${subcategoryID}`), 400)
  }

  function Logout() {
    sessionStorage.clear();
    navigate("/loginpage");
  }

  return (
    <div>
      <Flex class='p-3'>
        {/* Breadcrumb Navigation */}
        <Breadcrumb>
          <BreadcrumbList class='text-base'>
            <BreadcrumbItem>
              <BreadcrumbLink href="/">Home</BreadcrumbLink>
            </BreadcrumbItem>
            <BreadcrumbSeparator />
            <BreadcrumbItem>
              <BreadcrumbLink current>{category()?.name}</BreadcrumbLink>
            </BreadcrumbItem>
            <BreadcrumbSeparator />
          </BreadcrumbList>
        </Breadcrumb>
        {/* --------------------- */}

        {/* Create new Category Dialog */}
        <Dialog onOpenChange={handleOpenChange}>
          <DialogTrigger><Button class={"cypressCreateSubcategoryButton"}>Create Subcategory</Button></DialogTrigger>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>Create Subcategory</DialogTitle>
              <DialogDescription> Create a new category here </DialogDescription>
            </DialogHeader>
            <div>
              <TextField>
                <TextFieldLabel>Name: </TextFieldLabel>
                <TextFieldInput class={"cypressSubcategoryNameInput"}
                  onChange={e => setNewSubcategory(e.target.value)}
                  type='text'
                  required />
              </TextField>
            </div>
            <DialogFooter>
              <Button class={"cypressSubcategorySubmitButton"} type='submit' onClick={() => CreateSubcategory()}>Create</Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
        {/* ------------------ */}

        <Button onClick={Logout}>Log out</Button>
      </Flex>

      {/* Subcategory Table */}
      <div class="mt-5">
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead class='font-bold text-black text-lg'>Name</TableHead>
              <TableHead class='font-bold text-black text-lg'>Edit</TableHead>
              <TableHead class='font-bold text-black text-lg'>Delete</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            <For each={category()?.subcategories}>
              {subcategory =>
                <TableRow class={"cypressSubcategoryItems"}>
                  <TableCell>
                    <Button class={"cypressSubcategoryItem"} variant={"link"} onClick={() => SubcategoryDetails(subcategory.id)}>{subcategory.name}</Button>
                  </TableCell>
                  <TableCell>

                    {/* Edit Category Dialog */}
                    <Dialog onOpenChange={handleOpenChange}>
                      <DialogTrigger><Button variant={'outline'} class='bg-blue-500 text-white'>Edit</Button></DialogTrigger>
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
                  <TableCell><Button class={"cypressSubcategoryItemDelete"} variant="destructive" onClick={() => DeleteSubcategory(subcategory.id)}>Delete</Button></TableCell>
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