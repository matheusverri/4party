from rest_framework import serializers
from .models import Cliente,Produto,Ingresso,ConsumoCliente,IngressoCliente,Sexo
class SexoSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=Sexo
        fields=['sexo']
        
class ClienteSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=Cliente
        fields=['id', 'nome', 'sexo','email','data_nascimento']
        extra_kwargs = {
            'url': {'view_name': 'sexo-detail', 'lookup_field': 'id'},
        }

class ProdutoSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=Produto
        fields=['id', 'nome', 'valor','unidade']

class IngressoSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=Ingresso
        fields=['id', 'nome', 'descricao','valor']

class ConsumoSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=ConsumoCliente
        fields=['id', 'cliente', 'produtos']

class IngressoClienteSerializer(serializers.HyperlinkedModelSerializer):
    class Meta:
        model=IngressoCliente
        fields=['id', 'cliente', 'ingresso']
    