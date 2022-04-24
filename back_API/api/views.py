from rest_framework import viewsets
from .serializer import ClienteSerializer,ConsumoSerializer,IngressoClienteSerializer,IngressoSerializer,ProdutoSerializer,SexoSerializer
from .models import Cliente,Produto,Ingresso,ConsumoCliente,IngressoCliente,Sexo

class SexoView(viewsets.ModelViewSet):
    queryset= Sexo.objects.all()
    serializer_class= SexoSerializer

class ClienteView(viewsets.ModelViewSet):
    queryset= Cliente.objects.all()
    serializer_class= ClienteSerializer

class ProdutoView(viewsets.ModelViewSet):
    queryset= Produto.objects.all()
    serializer_class= ProdutoSerializer

class IngressoView(viewsets.ModelViewSet):
    queryset= Ingresso.objects.all()
    serializer_class= IngressoSerializer

class ConsumoView(viewsets.ModelViewSet):
    queryset= ConsumoCliente.objects.all()
    serializer_class= ConsumoSerializer

class IngressoClienteView(viewsets.ModelViewSet):
    queryset= IngressoCliente.objects.all()
    serializer_class= IngressoClienteSerializer