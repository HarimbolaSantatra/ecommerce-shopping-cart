import requests

PORT = 5180 # look at Properties/launchSettings.json
BASE_URL = f"http://localhost:{PORT}/shoppingcart"

def test_endpoint():
    endpoint = f"{BASE_URL}"
    # headers = {
    #         'Content-Type': 'application/json'
    #         }
    resp = requests.get(
            endpoint,
            )
    return resp
    

def get(user_id: int):
    endpoint = f"{BASE_URL}/{user_id}"
    headers = {
            'Content-Type': 'application/json'
            }
    resp = requests.get(
            endpoint,
            headers=headers
            )
    return resp
    

def add_item(user_id: int):
    endpoint = f"{BASE_URL}/{user_id}/item"
    data = {
            "productCatalogueId": 1,
            "productName": "toothpaste",
            "description": "Toothpaste for toothbrush",
            "price": 3,
            }
    headers = {
            'Content-Type': 'application/json'
            }
    resp = requests.post(
            endpoint,
            data=data,
            headers=headers
            )
    return resp

def main():
    userid = 1

    test = test_endpoint()
    print(test.status_code)
    print(test.text)

    getuser = get(userid)
    print(getuser.status_code)
    print(getuser.text)

    resp = add_item(userid)
    print(resp.status_code)
    print(resp.text)

if __name__ == '__main__':
    main()
