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

const SubcategoryPage: Component = () => {
    const navigate = useNavigate()

    const SessionToken = String(sessionStorage.getItem("SessionToken"))
    if (SessionToken.length == 0) {
        navigate("/LoginPage")
    }

    const CategoryID = Number(sessionStorage.getItem("CategoryID"))
    const SubcategoryID = Number(sessionStorage.getItem("SubcategoryID"))

    const [category] = createResource<Category | undefined>(() => fetch(`http://api.localhost/categories/${CategoryID}`).then(body => body.json()))
    const [subcategory, { refetch }] = createResource<Subcategory | undefined>(() => fetch(`http://api.localhost/categories/${CategoryID}/subcategories/${SubcategoryID}`).then(body => body.json()))

    const [productName, setProductName] = createSignal("")
    const [productBrand, setProductBrand] = createSignal("")
    const [productCurrentStock, setProductCurrentStock] = createSignal(0)
    const [productMinStock, setProductMinStock] = createSignal(0)
    const [productMaxStock, setProductMaxStock] = createSignal(0)

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

    function CreateProduct() {
        if (productName() !== "" && productBrand() !== "") {
            fetch(`http://api.localhost/products?name=${productName()}&brand=${productBrand()}&subcategoryID=${SubcategoryID}&currentStock=${productCurrentStock()}&minStock=${productMinStock()}&maxStock=${productMaxStock()}`, {
                method: "POST"
            }).then((response) => {
                const statusCode = Number.parseInt(response.status.toString());
                setResponseCode(statusCode);
                switch (responseCode().toString().substring(0, 2)) {
                    case "20":
                        showToast({ title: "Product Added", variant: "success" })
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

    function UpdateProduct(productID: number) {
        if (productName() !== "" && productBrand() !== "") {
            fetch(`http://api.localhost/products/${productID}?name=${productName()}&brand=${productBrand()}&subcategoryID=${SubcategoryID}&currentStock=${productCurrentStock()}&minStock=${productMinStock()}&maxStock=${productMaxStock()}`, {
                method: "PUT"
            }).then((response) => {
                const statusCode = Number.parseInt(response.status.toString());
                setResponseCode(statusCode);
                switch (responseCode().toString().substring(0, 2)) {
                    case "20":
                        showToast({ title: "Product Updated", variant: "success" })
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

    function DeleteProduct(productID: number) {
        if (confirm("Are you sure you want to delete this category?")) {
            fetch(`http://api.localhost/products/${productID}`, {
                method: "DELETE"
            }).then(() => {
                refetch()
            })
        }
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
                            <BreadcrumbLink href={`/categorypage/${category()?.id}`}>{category()?.name}</BreadcrumbLink>
                        </BreadcrumbItem>
                        <BreadcrumbSeparator />
                        <BreadcrumbItem>
                            <BreadcrumbLink current>{subcategory()?.name}</BreadcrumbLink>
                        </BreadcrumbItem>
                        <BreadcrumbSeparator />
                    </BreadcrumbList>
                </Breadcrumb>
                {/* --------------------- */}

                {/* Create new Product Dialog */}
                <Dialog onOpenChange={handleOpenChange}>
                    <DialogTrigger><Button class={"cypressCreateProductButton"}>Create Product</Button></DialogTrigger>
                    <DialogContent>
                        <DialogHeader>
                            <DialogTitle>Create Product</DialogTitle>
                            <DialogDescription> Create a new product here </DialogDescription>
                        </DialogHeader>
                        <div>
                            <TextField>
                                <TextFieldLabel>Name: </TextFieldLabel>
                                <TextFieldInput class={"cypressProductNameInput"}
                                    onChange={e => setProductName(e.target.value)}
                                    type='text'
                                    required />
                            </TextField>
                            <TextField>
                                <TextFieldLabel>Brand: </TextFieldLabel>
                                <TextFieldInput class={"cypressProductBrandInput"}
                                    onChange={e => setProductBrand(e.target.value)}
                                    type='text'
                                    required />
                            </TextField>
                            <TextField>
                                <TextFieldLabel>Current Stock: </TextFieldLabel>
                                <TextFieldInput class={"cypressProductCurrentStockInput"}
                                    value={0}
                                    onChange={e => setProductCurrentStock(Number(e.target.value))}
                                    type='number' />
                            </TextField>
                            <TextField>
                                <TextFieldLabel>Min Stock: </TextFieldLabel>
                                <TextFieldInput class={"cypressProductMinStockInput"}
                                    value={0}
                                    onChange={e => setProductMinStock(Number(e.target.value))}
                                    type='number' />
                            </TextField>
                            <TextField>
                                <TextFieldLabel>Max Stock: </TextFieldLabel>
                                <TextFieldInput class={"cypressProductMaxStockInput"}
                                    value={0}
                                    onChange={e => setProductMaxStock(Number(e.target.value))}
                                    type='number' />
                            </TextField>
                        </div>
                        <DialogFooter>
                            <Button class={"cypressProductSubmitButton"} type='submit' onClick={() => CreateProduct()}>Create</Button>
                        </DialogFooter>
                    </DialogContent>
                </Dialog>
                {/* ------------------ */}

                <Button onClick={Logout}>Log out</Button>
            </Flex>

            {/* Product Table */}
            <div class="mt-5">
                <Table>
                    <TableHeader>
                        <TableRow>
                            <TableHead class='font-bold text-black text-lg'>Name</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Brand</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Current Stock</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Min Stock</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Max Stock</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Edit</TableHead>
                            <TableHead class='font-bold text-black text-lg'>Delete</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        <For each={subcategory()?.products}>
                            {product =>
                                <TableRow class={"cypressProductItems"}>
                                    <TableCell>
                                        {product.name}
                                    </TableCell>
                                    <TableCell>
                                        {product.brand}
                                    </TableCell>
                                    <TableCell>
                                        {product.currentStock}
                                    </TableCell>
                                    <TableCell>
                                        {product.minStock}
                                    </TableCell>
                                    <TableCell>
                                        {product.maxStock}
                                    </TableCell>
                                    <TableCell>

                                        {/* Edit Product Dialog */}
                                        <Dialog onOpenChange={handleOpenChange}>
                                            <DialogTrigger><Button variant={'outline'} class='bg-blue-500 text-white'>Edit</Button></DialogTrigger>
                                            <DialogContent>
                                                <DialogHeader>
                                                    <DialogTitle>Update Product</DialogTitle>
                                                    <DialogDescription> Update product: {product.name} here </DialogDescription>
                                                </DialogHeader>
                                                <div>
                                                    <TextField>
                                                        <TextFieldLabel>Name: </TextFieldLabel>
                                                        <TextFieldInput
                                                            value={product.name}
                                                            onChange={e => setProductName(e.target.value)}
                                                            type='text'
                                                            required />
                                                    </TextField>
                                                    <TextField>
                                                        <TextFieldLabel>Brand: </TextFieldLabel>
                                                        <TextFieldInput
                                                            value={product.brand}
                                                            onChange={e => setProductBrand(e.target.value)}
                                                            type='text'
                                                            required />
                                                    </TextField>
                                                    <TextField>
                                                        <TextFieldLabel>Current Stock: </TextFieldLabel>
                                                        <TextFieldInput
                                                            value={product.currentStock}
                                                            onChange={e => setProductCurrentStock(Number(e.target.value))}
                                                            type='number' />
                                                    </TextField>
                                                    <TextField>
                                                        <TextFieldLabel>Min Stock: </TextFieldLabel>
                                                        <TextFieldInput
                                                            value={product.minStock}
                                                            onChange={e => setProductMinStock(Number(e.target.value))}
                                                            type='number' />
                                                    </TextField>
                                                    <TextField>
                                                        <TextFieldLabel>Max Stock: </TextFieldLabel>
                                                        <TextFieldInput
                                                            value={product.maxStock}
                                                            onChange={e => setProductMaxStock(Number(e.target.value))}
                                                            type='number' />
                                                    </TextField>
                                                </div>
                                                <DialogFooter>
                                                    <Button type='submit' onClick={() => UpdateProduct(product.id)}>Update</Button>
                                                </DialogFooter>
                                            </DialogContent>
                                        </Dialog>
                                        {/* -------------------- */}

                                    </TableCell>
                                    <TableCell><Button class={"cypressProductItemDelete"} variant="destructive" onClick={() => DeleteProduct(product.id)}>Delete</Button></TableCell>
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

export default SubcategoryPage