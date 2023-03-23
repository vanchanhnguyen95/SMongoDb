console.log("Hello from Lemon")
/**
 * # Docker image basic
 * 1. Ứng dụng này cần chạy trên OS nào?
 * 2. Phải cài đặt những gì
 * 3. Sao chép các file cần thiết để thực thi
 * 4. Câu lệnh nào để chạy ứng dụng
 * docker build -t hello-docker-lemon .
 * Cau lenh xem image hien tai dang co: docker image ls
 * 
 * Cau lenh chay image vua tao ra (lúc này không cần thiết đứng tại thư mục nào nữa):
 * docker run hello-docker-lemon
 * 
 * Đẩy lên repository, muốn image tên là gì
 * docker tag local-image:tagname new-repo:tagname
 * docker push new-repo:tagname
 * 
 * docker tag hello-docker-lemon:v1 hello-docker
 * docker tag hello-docker-lemon:latest hello-docker
 * docker push hello-docker:v1
 * 
 * Bị lỗi: denied: requested access to the resource is denied (vì chưa login)
 * 
 * Cần login như sau:
 * docker login
 * Nhập user name, pass vẫn bị lỗi
 * denied: requested access to the resource is denied
 * 
 * Cần làm lại, cần lấy tên theo repository theo user name đã, đẩy lại
 * docker tag hello-docker:v1 lemonnguyen/hello-docker:v1
 * docker push lemonnguyen/hello-docker:v1
 * 
 * Trang web test pull docker về chạy trên máy ảo
 * https://labs.play-with-docker.com/p/cgds8so1k7jg00fq7ljg#cgds8so1_cgds8vo1k7jg00fq7lk0
 * 
 * Câu lệnh pull image từ docker về
 * docker pull lemonnguyen/hello-docker:v1
 * 
 * Kiểm tra image nào đang tồn tại
 * docker images
 * 
 * Chạy image vừa pull về
 * docker run lemonnguyen/hello-docker:v1
 * 
 */