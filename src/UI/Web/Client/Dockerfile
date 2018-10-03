FROM nginx:alpine
COPY src/UI/Web/Client/nginx.conf /etc/nginx/nginx.conf
RUN rm -rf /usr/share/nginx/html/*
COPY src/UI/Web/Client/dist/Client/* /usr/share/nginx/html/
WORKDIR /usr/share/nginx/html
COPY src/UI/Web/Client/dist/ .
